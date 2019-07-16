/**
 * License: MIT
 * Author: Kevin Villanueva
 * Contact: https://github.com/rhaldkhein
 */

using System.Threading.Tasks;
using server.Helpers.Errors;

namespace server.Helpers {
  public interface IAsyncResult<T> {

    Error Error { get; set; }
    T Payload { get; set; }
    Metadata Metadata { get; set; }


    IAsyncResult<T> Resolve(T payload, Metadata metadata = null);
    IAsyncResult<T> Reject(Error error);
    IAsyncResult<T> Reject<T1>(IAsyncResult<T1> error);

    bool IsResolved();
    bool IsRejected();

    IAsyncResult<T> Clear();
    IAsyncResult<T1> Cast<T1>();
    IAsyncResult<T1> Cast<T1>(T1 payload);
    IAsyncResult<T1> Cast<T1>(System.Func<T, T1> payloadMapper);

    IAsyncResult<T> AsIAsyncResult();
    Task<IAsyncResult<T>> AsTaskResult();

  }
}