function orders (product, quantity) {
    'use strict';

    let price = 0;
    let totalPrice = 0;

    switch (product) {
        case 'coffee':
            price = 1.5;
            break;
        case 'water':
            price = 1;
            break;
        case 'coke':
            price = 1.4;
            break;
        case 'snacks':
            price = 2;
            break;
    }

    totalPrice = price * quantity;
    console.log(totalPrice.toFixed(2));
}