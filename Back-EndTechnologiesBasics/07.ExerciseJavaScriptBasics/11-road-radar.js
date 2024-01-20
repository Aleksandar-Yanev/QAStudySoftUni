function solve(currentSpeed, area) {
    'use strict';

    let speedLimit = 0;

    switch (area) {
        case 'motorway':
            speedLimit = 130;
            break;
        case 'interstate':
            speedLimit = 90;
            break;
        case 'city':
            speedLimit = 50;
            break;
        case 'residential':
            speedLimit = 20;
            break;
    }

    const speedDiference = currentSpeed - speedLimit;
    let status = '';

    if (speedDiference <= 0){
        console.log (`Driving ${currentSpeed} km/h in a ${speedLimit} zone`);
    } else if (speedDiference > 0 && speedDiference <= 20){
        status = 'speeding';
        console.log (`The speed is ${speedDiference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    } else if (speedDiference > 20 && speedDiference <= 40){
        status = 'excessive speeding';
        console.log (`The speed is ${speedDiference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    } else {
        status = 'reckless driving';
        console.log (`The speed is ${speedDiference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }
}

solve (40, 'city');
solve (21, 'residential');
solve (120, 'interstate');
solve (200, 'motorway');