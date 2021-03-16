using Mug.Interfaces;
using MugDomain;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MugDomain.Enumerations;
using MugDomain.Objects;
using System.Linq;

namespace Mug.Services
{
    public class MugService : IMugService
    {
        private readonly MugDBContext mugDBConext;

        public MugService(MugDBContext mugDBConext)
        {
            this.mugDBConext = mugDBConext;
        }

        public async Task<Cup> UseMug(MugSizeEnum size)
        {
            
            var mug = await mugDBConext.Mugs.FirstOrDefaultAsync(x => x.Size == (int)size);

            if (mug == null)
            {
                return null;
            }

             DebitCup(mug.Id, 1);

            return new Cup(){ Size = mug.Size};
        }


        public  void DebitCup(int id,int quantity)
        {
            var mug =   mugDBConext.Mugs.First(x => x.Id == id);
            mug.Quantity -= quantity;
            mugDBConext.Entry(mug).State = EntityState.Modified;
            mugDBConext.SaveChanges();
        }

        public  void CriditCup(int id, int quantity)
        {
            var mug =  mugDBConext.Mugs.First(x => x.Id == id);
            mug.Quantity += quantity;
            mugDBConext.Entry(mug).State = EntityState.Modified;
            mugDBConext.SaveChanges();
        }
    }
}
