using System;
using System.Diagnostics;

namespace MinoTool
{
    /// <summary>
    /// 计时器工具类
    /// </summary>
    public static class StopwatchUtil
    {
        /// <summary>
        /// 计时器结束事件
        /// </summary>
        private static Action<Stopwatch> OnStopwatch = defaultOnStopwatch;

        /// <summary>
        /// 创建实现IDisposable接口的计时器
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public static StopwatchClass CreateStopwatch(Action<Stopwatch> action = null)
        {
            return new StopwatchClass(action == null ? OnStopwatch : action);
        }

        /// <summary>
        /// 设置计时器结束事件
        /// </summary>
        /// <param name="action"></param>
        public static void SetOnStopwatch(Action<Stopwatch> action)
        {
            OnStopwatch = action;
        }

        /// <summary>
        /// 默认的计时器结束事件
        /// </summary>
        /// <param name="stopwatch"></param>
        private static void defaultOnStopwatch(Stopwatch stopwatch)
        {
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        /// <summary>
        /// 实现IDisposable接口的计时器
        /// </summary>
        public class StopwatchClass : IDisposable
        {
            private Stopwatch stopwatch;
            private Action<Stopwatch> onStopwatchStop;
            internal StopwatchClass(Action<Stopwatch> action)
            {
                this.onStopwatchStop = action;
                this.stopwatch = new Stopwatch();
                this.stopwatch.Start();
            }

            public void Dispose()
            {
                this.stopwatch.Stop();
                this.onStopwatchStop?.Invoke(this.stopwatch);
            }
        }
    }
}