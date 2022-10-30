using Abp.Web.Mvc.Views;

namespace TCache.Web.Views
{
    public abstract class TCacheWebViewPageBase : TCacheWebViewPageBase<dynamic>
    {

    }

    public abstract class TCacheWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected TCacheWebViewPageBase()
        {
            LocalizationSourceName = TCacheConsts.LocalizationSourceName;
        }
    }
}