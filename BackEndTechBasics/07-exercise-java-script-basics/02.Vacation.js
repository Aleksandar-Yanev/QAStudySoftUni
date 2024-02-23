function vacantion(numberOfPeople, typeOfGroup, dayOfWeek) {
    'use strict';

    let price;
    let totalPrice;
    switch (typeOfGroup) {
        case 'Students':
            switch (dayOfWeek) {
                case 'Friday':
                    price = 8.45;
                    break;
                case 'Saturday':
                    price = 9.80;
                    break;
                case 'Sunday':
                    price = 10.46;
                    break;
            }
            break;
        case 'Business':
            switch (dayOfWeek) {
                case 'Friday':
                    price = 10.90;
                    break;
                case 'Saturday':
                    price = 15.60;
                    break;
                case 'Sunday':
                    price = 16;
                    break;
            }
            break;
        case 'Regular':
            switch (dayOfWeek) {
                case 'Friday':
                    price = 15;
                    break;
                case 'Saturday':
                    price = 20;
                    break;
                case 'Sunday':
                    price = 22.5;
                    break;
            }
            break;       
    }

    if (typeOfGroup === 'Students' && numberOfPeople >=30){
        totalPrice = price * numberOfPeople * 0.85;
    }
    else if (typeOfGroup === 'Business' && numberOfPeople >= 100){
        totalPrice = (numberOfPeople - 10) * price;
    }
    else if (typeOfGroup === 'Regular' && numberOfPeople >= 10 && numberOfPeople <= 20 ){
        totalPrice = price * numberOfPeople * 0.95;
    }
    else{
        totalPrice = price * numberOfPeople;
    }

    
    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

vacantion(30, 'Students', 'Sunday');
vacantion(40, "Regular", "Saturday");