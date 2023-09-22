using System;

namespace CodeBase.Infrastructure
{
   public static class DevelopExtensions
   {
      public static TValue With<TValue>(this TValue obj, Action<TValue> action)
      {
         action.Invoke(obj);
         return obj;
      }
   }
}