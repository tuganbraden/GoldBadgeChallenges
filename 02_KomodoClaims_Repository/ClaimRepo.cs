using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_KomodoClaims_Repository
{
    public class ClaimRepo
    {
        private Queue<Claim> _claimsQueue = new Queue<Claim>();
        
        // CREATE
        public void AddClaim(Claim newClaim)
        {
            _claimsQueue.Enqueue(newClaim);
        }

        // READ
        public Queue<Claim> GetQueue()
        {
            return _claimsQueue;
        }

        // UPDATE/DELETE
        public void HandleClaim()
        {
            Claim handled = _claimsQueue.Dequeue();
        }

    }
}
