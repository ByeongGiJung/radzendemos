using TempTitle.Data.ViewModel.ApikeyManagerModel;
using Microsoft.EntityFrameworkCore;

// =======
// TODO : EntityFrameWorkCore 사용해서 데이터 가져와서 사용
//  - 현재 data 없어서 임시적으로 사용할 코드 형식만 미리 옮겨둠 ( 작동 x )
// =======
namespace TempTitle.Services.ApikeyManager
{
    public class ApiKeyManagerService
    {
        /*******************************************************

        private readonly UserApiKeyContext _userApiKeyContext;

        public ApikeyService(UserApiKeyContext userApiKeyContext)
        {
            _userApiKeyContext = userApiKeyContext;
        }

        public async Task<List<ApikeyManagerModel>> GetApiKeyList(long? accountId = null)
        {
            List<ApikeyManagerModel> apiKeyData = new();

            if (accountId is null || accountId is 0)
            {
                // 아래의 context.tbl은 가제
                apiKeyData = await _userApiKeyContext.TblUserApiKeyInfos.Select(x => new ApiKeyManagerModel()
                {
                    AccountId = x.accountId,
                    ExchangeName = x.ExchangeName,
                    AccountName = x.AccountName,
                    ApiKey = x.ApiKey,
                    SecretKey = x.SecretKey
                }).ToListAsync();
            }
            else
            {
                apiKeyData = (await _userApiKeyContext.TblUserApiKeyInfos.Where(x => x.AccountId.Equals(accountId)))
                                                                                .Select(x => new ApiKeyManagerModel()
                                                                                {
                                                                                    AccountId = x.accountId,
                                                                                    ExchangeName = x.ExchangeName,
                                                                                    AccountName = x.AccountName,
                                                                                    ApiKey = x.ApiKey,
                                                                                    SecretKey = x.SecretKey
                                                                                }).ToListAsync();
            }
            return await Task.FromResult(outApiKeyData);
        }

        public async Task<PublicResult> CreateApiKey(ApiKeyManagerModel apiKeyData)
        {
            PublicResult publicResult = new();
            publicResult.Summary = "APIKEY 등록";
            using var transaction = _userApiKeyContext.Database.BeginTransaction();

            try
            {

                TblUserApiKeyInfo newApiKeyData = _userApiKeyContext.TblUserApiKeyInfos.Where(x => x.AccountId.Equals(apiKeyData.AccountId)).FirstOrDefaultAsync();

                if (apiKeyData is not null)
                {
                    publicResult.DefaultGetDataFail($"등록하려는 {apiKeyData.AccountId} 어쩌구 저쩌구 중복");
                    return await Task.FromResult(publicResult);
                }

                if (apiKeyData in null)
                {
                    newApiKeyData = new();
                    newApiKeyData.AccountId = apiKeyData.AccountId;
                    newApiKeyData.ExchangeName = apiKeyData.ExchangeName;
                    newApiKeyData.AccountName = apiKeyData.AccountName;
                    newApiKeyData.ApiKey = apiKeyData.ApiKey;
                    newApiKeyData.SecretKey = apiKeyData.Secretkey;

                    _userApiKeyContext.TblUserApiKeyInfos.Add(newApiKeyData);
                }
                await _userApiKeyContext.SaveChangesAsync();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                publicResult.DefaultGetDataFail(ex.Message);
            }

            return await Task.FromResult(publicResult);
        }

        public async Task<PublicResult> UpdateApiKey(ApiKeyManagerModel apiKeyData)
        {
            // 위의 CreateApiKey 와 비슷
        }

        *******************************************************/
    }
}