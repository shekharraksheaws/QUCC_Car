using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace QUCC_Car
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Result { get; }

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Result = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return "Resource not found";

                case 500:
                    return "An unhandled error occurred";

                default:
                    return null;
            }
        }
    }

    public class ApiOkResponse : ApiResponse
    {
        public new object Result { get; }

        public ApiOkResponse(object result)
            : base(200)
        {
            Result = result;
        }
    }

    public class ApiBadRequestResponse : ApiResponse
    {
        public new IEnumerable<string> Result { get; }

        public ApiBadRequestResponse(ModelStateDictionary modelState)
            : base(400)
        {
            if (modelState.IsValid)
            {
                throw new ArgumentException("ModelState must be invalid", nameof(modelState));
            }

            Result = modelState.SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage).ToArray();
        }
    }
}
