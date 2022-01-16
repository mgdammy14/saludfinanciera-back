using System;
using ApiDataAccess.General;
using ApiModel.Mensajes;
using ApiRepositories.Mensajes;

namespace ApiDataAccess.Mensajes
{
    public class MessageRepository : Repository<Message> , IMessageRepository
    {
        public MessageRepository(string connectionsString) : base(connectionsString)
        {
        }
    }
}
