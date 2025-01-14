// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The HttpRequestParameter. </summary>
    internal partial class HttpRequestParameter
    {
        /// <summary> Initializes a new instance of HttpRequestParameter. </summary>
        /// <param name="url"> HTTP URL. </param>
        /// <param name="httpHeader"> HTTP header. </param>
        /// <param name="httpMethod"> HTTP method. </param>
        /// <param name="payload"> HTTP request body. </param>
        public HttpRequestParameter(string url, string httpHeader, string httpMethod, string payload)
        {
            Url = url;
            HttpHeader = httpHeader;
            HttpMethod = httpMethod;
            Payload = payload;
        }

        /// <summary> HTTP URL. </summary>
        public string Url { get; set; }
        /// <summary> HTTP header. </summary>
        public string HttpHeader { get; set; }
        /// <summary> HTTP method. </summary>
        public string HttpMethod { get; set; }
        /// <summary> HTTP request body. </summary>
        public string Payload { get; set; }
    }
}
