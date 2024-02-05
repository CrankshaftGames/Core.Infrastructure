using System.Threading.Tasks;

namespace Core.Infrastructure.Commands
{
    public abstract class Command<T>
    {
        public abstract Task<T> Execute();
    }

    public abstract class Command
    {
        public abstract Task Execute();
    }
}