using Newtonsoft.Json;
using RestSharp;
using TestApiProject.ApiRequests.Models;
using TestApiProject.ApiRequests.Url;

namespace TestApiProject.ApiRequests.NewBookModelsApi.Client
{
    public class ClientRequests
    {
        public ClientProfileModel SendRequestUpdateProfileInformation(ClientProfileModel updateProfileModel)
        {
            var response = new RestRequestBuilder(NewBookModelsUrl.GetBaseUrl("1"), NewBookModelsUrl.Profile.Update())
                .AddParametersAsJsonRowInRequestBody(updateProfileModel)
                .AddMethodType(Method.PATCH)
                .AddHeader("content-type", "application/json")
                .AddHeader("authorization", Context.Token)
                .AddRequestFormat(DataFormat.Json)
                .Execute();
            
            return JsonConvert.DeserializeObject<ClientProfileModel>(response.Content);
        }

        public AvatarUploadModel SendRequestUploadUserAvatar(string filePath)
        {
            var response = new RestRequestBuilder(NewBookModelsUrl.GetBaseUrl(), NewBookModelsUrl.Images.ChangeAvatar())
                .AddFile(filePath)
                .AddMethodType(Method.POST)
                .AddHeader("authorization", Context.Token)
                .AddHeader("Content-type", "multipart/form-data")
                .Execute();
            
            return JsonConvert.DeserializeObject<AvatarUploadModel>(response.Content);
        }

        public UserModel SendRequestSetNewAvatar(AvatarSetModel avatarSetModel)
        {
            var response = new RestRequestBuilder(NewBookModelsUrl.GetBaseUrl("1"), NewBookModelsUrl.Profile.UpdateSelfInfo())
                .AddParametersAsJsonRowInRequestBody(avatarSetModel)
                .AddMethodType(Method.PATCH)
                .AddHeader("authorization", Context.Token)
                .AddHeader("content-type", "application/json")
                .AddRequestFormat(DataFormat.Json)
                .Execute();

            return JsonConvert.DeserializeObject<UserModel>(response.Content);
        }
        
        public UserModel SendRequestToGetClientInfo()
        {
            
            var response = new RestRequestBuilder(NewBookModelsUrl.GetBaseUrl("1"), NewBookModelsUrl.Profile.UpdateSelfInfo())
               .AddMethodType(Method.GET)
               .AddHeader("authorization", Context.Token)
               .AddHeader("content-type", "application/json")
               .AddRequestFormat(DataFormat.Json)
               .Execute();

            return JsonConvert.DeserializeObject<UserModel>(response.Content);

        }


    }
}
