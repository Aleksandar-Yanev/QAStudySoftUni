import {createCalculator} from './04-add-substract.js';
import {assert} from 'chai';

describe('createCalculator', function () {
    it('should return an object with add(), subtract(), and get() functions', function () {
        const calculator = createCalculator();
        assert.isObject(calculator);
        assert.isFunction(calculator.add);
        assert.isFunction(calculator.subtract);
        assert.isFunction(calculator.get);
    });

    it('should keep an internal sum that cannot be modified from the outside', function () {
        const calculator = createCalculator();
        calculator.add(5);
        assert.equal(calculator.get(), 5);
        // Try to modify the internal sum directly
        calculator.value = 10;
        assert.equal(calculator.get(), 5);
    });

    it('should correctly add and subtract numbers from the internal sum', function () {
        const calculator = createCalculator();
        calculator.add(5);
        calculator.subtract(3);
        calculator.add('10');
        assert.equal(calculator.get(), 12);
    });

    it('should parse number strings correctly when adding and subtracting', function () {
        const calculator = createCalculator();
        calculator.add('5');
        calculator.subtract('3');
        assert.equal(calculator.get(), 2);
    });

    it('should handle invalid input gracefully when adding and subtracting', function () {
        const calculator = createCalculator();
        calculator.add('abc');
        assert.isNaN(calculator.get());
        calculator.subtract('xyz');
        assert.isNaN(calculator.get());
    });
});