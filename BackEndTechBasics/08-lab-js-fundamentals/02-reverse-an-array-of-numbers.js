function reverse(number, inputArray) {
    'use strict';

    let arr = [];

/*for (let i = 0; i < number; i++) {
        arr.push(inputArray[i]);
    }

    let output = '';
    for (let j = arr.length - 1; j >= 0; j--) {
        output +=` ${arr[j]}`;
    }

    console.log(output.trimEnd());
    */
    for (let i = 0; i < number; i++){
        arr.unshift(inputArray[i]);
    }

    console.log(arr.join(" "));

}

reverse (3, [10, 20, 30, 40, 50]);