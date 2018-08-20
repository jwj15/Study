/**
 *  callbackFucntion
 *  
 *  비동기 방식 함수
 *  
 *  
 */
//ex
function square(x, callback) {
    setTimeout(callback, 100, x*x);
}
 
square(2, function(number) {
    console.log(number);
});

// square 함수가 실행되고 나서 callback실행