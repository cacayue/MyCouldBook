

using Abp.Domain.Services;

namespace MyCouldBook
{
	public abstract class MyCouldBookDomainServiceBase : DomainService
	{
		/* Add your common members for all your domain services. */
		/*在领域服务中添加你的自定义公共方法*/





		protected MyCouldBookDomainServiceBase()
		{
			LocalizationSourceName = MyCouldBookConsts.LocalizationSourceName;
		}
	}
}
