using NXHOANG.ApplicationCore.Entity;
using NXHOANG.ApplicationCore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NXHOANG.ApplicationCore.EtensionMethod
{
    public static class EntityExtension
    {

        public static void UpdateOrder(this ProductOrder productOrder, ProductOrderViewModel productOrderVm)
        {
            productOrder.UserId = productOrderVm.UserId;
            productOrder.UserName = productOrderVm.UserName;
            productOrder.UserAddress = productOrderVm.UserAddress;
            productOrder.UserEmail = productOrderVm.UserEmail;
            productOrder.UserPhone = productOrderVm.UserPhone;
            productOrder.UserMessage = productOrderVm.UserMessage;
            productOrder.CreatedDate = DateTime.Now;
            productOrder.Status = productOrderVm.Status;
        }

    }
}
