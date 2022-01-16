using System;
using ApiModel.Mensajes;
using ApiRepositories.General;

namespace ApiRepositories.Mensajes
{
    public interface IMessageRepository : IRepository<Message>
    {
    }
}
