/**
 * License: MIT
 * Author: Kevin Villanueva
 * Contact: https://github.com/rhaldkhein
 */

using System.Threading.Tasks;
using server.Helpers.Errors;

namespace server.Helpers {
  public class Metadata {
    public object Payload { get; set; }
    public Metadata(object payload) {
      Payload = payload;
    }
  }

  // Async result that bundles payload and error object
  // without throwing an exception for performance boost
  public class AsyncResult<T> : IAsyncResult<T> {

    private bool resolved = false;
    public Error Error { get; set; }
    public Metadata Metadata { get; set; }
    public T Payload { get; set; }

    public AsyncResult() { }
    public AsyncResult(T payload) {
      resolved = true;
      Payload = payload;
    }
    public AsyncResult(T payload, Metadata meta) {
      resolved = true;
      Payload = payload;
      Metadata = meta;
    }
    public AsyncResult(Error error) {
      Error = error;
    }
    public AsyncResult(T payload, Error error) {
      resolved = true;
      Payload = payload;
      Error = error;
    }

    public IAsyncResult<T> Resolve(T payload, Metadata metadata = null) {
      resolved = true;
      this.Payload = payload;
      this.Metadata = metadata;
      return this;
    }
    public IAsyncResult<T> Reject(Error error) {
      this.Error = error;
      return this;
    }
    public IAsyncResult<T> Reject<T1>(IAsyncResult<T1> asyncResult) {
      this.Error = asyncResult.Error;
      return this;
    }

    public bool IsResolved() {
      return this.resolved;
    }
    public bool IsRejected() {
      return this.Error != null;
    }

    public IAsyncResult<T> Clear() {
      return new AsyncResult<T>();
    }
    public IAsyncResult<T1> Cast<T1>() {
      return new AsyncResult<T1>(this.Error);
    }
    public IAsyncResult<T1> Cast<T1>(T1 payload) {
      return new AsyncResult<T1>(payload, this.Error);
    }
    public IAsyncResult<T1> Cast<T1>(System.Func<T, T1> payloadMapper) {
      var to = new AsyncResult<T1>(this.Error);
      to.Resolve(payloadMapper.Invoke(this.Payload));
      return to;
    }

    public IAsyncResult<T> AsIAsyncResult() {
      return (IAsyncResult<T>)this;
    }
    public Task<IAsyncResult<T>> AsTaskResult() {
      return Task.FromResult(this.AsIAsyncResult());
    }

  }
}