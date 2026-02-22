using System.Collections;
using UnityEngine;

namespace Code.Infrastructure.Boot
{
  public interface ICoroutineRunner
  {
    Coroutine StartCoroutine(IEnumerator routine);
  }
}