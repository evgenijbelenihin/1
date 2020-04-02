using System;
using System.Net;
using RestSharp;

namespace TestApiProject
{
    public static class ResponseHandler
    {
        public static void AnalyzeStatusCode(this IRestResponse response)
        {
            if (response.StatusCode != HttpStatusCode.Accepted
                || response.StatusCode != HttpStatusCode.Created
                || response.StatusCode != HttpStatusCode.OK
                || response.StatusCode != HttpStatusCode.NonAuthoritativeInformation
                || response.StatusCode != HttpStatusCode.PartialContent
                || response.StatusCode != HttpStatusCode.ResetContent)
                throw new Exception(response.Content);
        }
    }
}
