using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N44_HT_Task1
{
    public class CancellationTokenService
    {

        public static async ValueTask Execution(CancellationToken cancellationToken)
        {
            for (var index = 0; index < 103; index++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    throw new TimeoutException("Time out ");
                }
            }
        }
    }
}
