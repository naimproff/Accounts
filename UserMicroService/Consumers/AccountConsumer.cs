using MassTransit;
using Newtonsoft.Json;
using SharedModels;
using SharedModels.MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UserMicroService.Repositories.Interfaces;

namespace UserMicroService.Consumers
{
    public class AccountConsumer : IConsumer<MessageTransit>
    {
        private readonly IUserRepository<User> _user;
        public AccountConsumer(IUserRepository<User> user)
        {
            _user = user;
        }


        public Task Consume(ConsumeContext<MessageTransit> context)
        {
            MessageTransit oMessageTransit = new MessageTransit();
            oMessageTransit = context.Message;

           string obj = oMessageTransit.CastObject;

         var DLL=   Assembly.LoadFile(@"D:\WorkStation\Naim\Ics_Conversion\Accounts\UserMicroService\bin\Debug\net5.0\SharedModels.dll");

            Type class1Type = DLL.GetType(oMessageTransit.CastObject);
            object ob = Activator.CreateInstance(class1Type);

            User oUser = JsonConvert.DeserializeObject<User>(oMessageTransit.Object);
           


            List<User> users = _user.GetAll();
            users = users.Where(x => x.UserName.Contains(oUser.UserName)).ToList();
            oMessageTransit.Objects = JsonConvert.SerializeObject(users);
            return context.RespondAsync(oMessageTransit);

            //return Task.CompletedTask;

        }
    }
}
