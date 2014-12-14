using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Sandbox.CrossCutting
{
    public interface ICommandHandler<TReq, TResp> where TReq : CommandRequest where TResp : CommandResponse
    {
	    TResp Invoke(TReq req);
    }
}
