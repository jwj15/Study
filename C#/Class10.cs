using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study
{
    // IDisposable 인터페이스 구현
    class Class10 : IDisposable
    {
        bool _isDisposed; // 중복 호출을 검색하려면

        // 종료자 destructor
        ~Class10()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this); //finalizer 호출 회피
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (!this._isDisposed)
            {
                if (isDisposing)
                {
                    // 관리되는 상태(관리되는 개체)를 삭제합니다.
                }
                // 관리되지 않는 리소스(관리되지 않는 개체)를 해제하고 아래의 종료자를 재정의합니다. 
                // 큰 필드를 null로 설정합니다.

                // 상태 변경
                this._isDisposed = true;
            }
        }
    }
}
