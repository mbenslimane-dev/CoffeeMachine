
using MugDomain.Enumerations;
using MugDomain.Objects;
using System.Threading.Tasks;

namespace Mug.Interfaces
{
    public interface IMugService
    {
         Task<Cup> UseMug(MugSizeEnum size);
        
         void DebitCup(int id, int quantity);

         void CriditCup(int id, int quantity);
    }
}
