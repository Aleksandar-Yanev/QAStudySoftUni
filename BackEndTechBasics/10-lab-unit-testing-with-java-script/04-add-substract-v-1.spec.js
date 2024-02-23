import {createCalculator} from './04-add-substract.js';
import {expect} from 'chai';

describe ('createCalculator', () =>{
     it('should return 0 if no operation are executed on the calculator', () => {
         //Arrange
         const calculator = createCalculator();
         //Act
         const result = calculator.get();
         //Assert
         expect(result).to.equal(0);
     });

    it('should return a negative number if only subtract operation are executed on the calculator', () => {
        //Arrange
        const calculator = createCalculator();
        //Act
        calculator.subtract(12);
        calculator.subtract(1);
        calculator.subtract(3);
        const result = calculator.get();
        //Assert
        expect(result).to.equal(-16);
    });

    it('should return a positive number  if only add operation are executed on the calculator', () => {
        //Arrange
        const calculator = createCalculator();
        //Act
        calculator.add(12);
        calculator.add(1);
        calculator.add(3);
        const result = calculator.get();
        //Assert
        expect(result).to.equal(16);
    });

    it('should handle number as string', () => {
        //Arrange
        const calculator = createCalculator();
        //Act
        calculator.subtract('5');
        calculator.add('9');
        const result = calculator.get();
        //Assert
        expect(result).to.equal(4);
    });

    it('should handle a mix of operations', () => {
        //Arrange
        const calculator = createCalculator();
        //Act
        calculator.add(-12);
        calculator.subtract(-1);
        calculator.add(-3);
        calculator.subtract(-9)
        const result = calculator.get();
        //Assert
        expect(result).to.equal(-5);
    });
});