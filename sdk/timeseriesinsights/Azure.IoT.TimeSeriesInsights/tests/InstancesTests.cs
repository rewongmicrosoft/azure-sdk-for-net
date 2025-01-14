﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.IoT.TimeSeriesInsights.Tests
{
    public class InstancesTests : E2eTestBase
    {
        private static readonly TimeSpan s_retryDelay = TimeSpan.FromSeconds(20);

        private const int MaxNumberOfRetries = 10;

        public InstancesTests(bool isAsync)
            : base(isAsync)
        {
        }

        [Test]
        public async Task TimeSeriesInsightsInstances_Lifecycle()
        {
            // Arrange
            TimeSeriesInsightsClient client = GetClient();
            int numOfIdProperties = 3;
            int numOfInstancesToSetup = 2;
            var timeSeriesInstances = new List<TimeSeriesInstance>();
            string defaultTypeId = await getDefaultTypeIdAsync(client).ConfigureAwait(false);

            for (int i = 0; i < numOfInstancesToSetup; i++)
            {
                TimeSeriesId id = await GetUniqueTimeSeriesInstanceIdAsync(client, numOfIdProperties)
                    .ConfigureAwait(false);

                var instance = new TimeSeriesInstance(id, defaultTypeId)
                {
                    Name = Recording.GenerateAlphaNumericId("instance"),
                };
                timeSeriesInstances.Add(instance);
            }

            IEnumerable<TimeSeriesId> timeSeriesInstancesIds = timeSeriesInstances.Select((instance) => instance.TimeSeriesId);

            // Act and assert
            try
            {
                await TestRetryHelper.RetryAsync<Response<InstancesOperationResult[]>>(async () =>
                {
                    // Create TSI instances
                    Response<TimeSeriesOperationError[]> createInstancesResult = await client
                        .Instances
                        .CreateOrReplaceAsync(timeSeriesInstances)
                        .ConfigureAwait(false);

                    // Assert that the result error array does not contain any object that is set
                    createInstancesResult.Value.Should().OnlyContain((errorResult) => errorResult == null);

                    // Get the created instances by Ids
                    Response<InstancesOperationResult[]> getInstancesByIdsResult = await client
                        .Instances
                        .GetAsync(timeSeriesInstancesIds)
                        .ConfigureAwait(false);

                    getInstancesByIdsResult.Value.Length.Should().Be(timeSeriesInstances.Count);
                    foreach (InstancesOperationResult instanceResult in getInstancesByIdsResult.Value)
                    {
                        instanceResult.Instance.Should().NotBeNull();
                        instanceResult.Error.Should().BeNull();
                        instanceResult.Instance.TimeSeriesId.ToArray().Length.Should().Be(numOfIdProperties);
                        instanceResult.Instance.TypeId.Should().Be(defaultTypeId);
                        instanceResult.Instance.HierarchyIds.Count.Should().Be(0);
                        instanceResult.Instance.InstanceFields.Count.Should().Be(0);
                    }

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);

                // Update the instances by adding descriptions to them
                timeSeriesInstances.ForEach((timeSeriesInstance) =>
                    timeSeriesInstance.Description = "Description");

                Response<InstancesOperationResult[]> replaceInstancesResult = await client
                    .Instances
                    .ReplaceAsync(timeSeriesInstances)
                    .ConfigureAwait(false);

                replaceInstancesResult.Value.Length.Should().Be(timeSeriesInstances.Count);
                replaceInstancesResult.Value.Should().OnlyContain((errorResult) => errorResult.Error == null);

                // This retry logic was added as the TSI instance are not immediately available after creation
                await TestRetryHelper.RetryAsync<Response<InstancesOperationResult[]>>(async () =>
                {
                    // Get instances by name
                    Response<InstancesOperationResult[]> getInstancesByNameResult = await client
                        .Instances
                        .GetAsync(timeSeriesInstances.Select((instance) => instance.Name))
                        .ConfigureAwait(false);

                    getInstancesByNameResult.Value.Length.Should().Be(timeSeriesInstances.Count);
                    foreach (InstancesOperationResult instanceResult in getInstancesByNameResult.Value)
                    {
                        instanceResult.Instance.Should().NotBeNull();
                        instanceResult.Error.Should().BeNull();
                        instanceResult.Instance.TimeSeriesId.ToArray().Length.Should().Be(numOfIdProperties);
                        instanceResult.Instance.TypeId.Should().Be(defaultTypeId);
                        instanceResult.Instance.HierarchyIds.Count.Should().Be(0);
                        instanceResult.Instance.InstanceFields.Count.Should().Be(0);
                    }

                    return null;
                }, MaxNumberOfRetries, s_retryDelay);

                // Get all Time Series instances in the environment
                AsyncPageable<TimeSeriesInstance> getAllInstancesResponse = client.Instances.GetAsync();

                int numOfInstances = 0;
                await foreach (TimeSeriesInstance tsiInstance in getAllInstancesResponse)
                {
                    numOfInstances++;
                    tsiInstance.Should().NotBeNull();
                }
                numOfInstances.Should().BeGreaterOrEqualTo(numOfInstancesToSetup);
            }
            finally
            {
                // clean up
                try
                {
                    Response<TimeSeriesOperationError[]> deleteInstancesResponse = await client
                        .Instances
                        .DeleteAsync(timeSeriesInstancesIds)
                        .ConfigureAwait(false);

                    // Assert that the response array does not have any error object set
                    deleteInstancesResponse.Value.Should().OnlyContain((errorResult) => errorResult == null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Test clean up failed: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
