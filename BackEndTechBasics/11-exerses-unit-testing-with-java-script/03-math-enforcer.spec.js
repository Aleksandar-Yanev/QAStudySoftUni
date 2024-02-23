import {mathEnforcer} from './03-math-enforcer.js';
import {expect} from "chai";

describe('mathEnforcer', () => {
    describe('addFive', () => {
        it('Should return undefined, when string parameter is given', () => {
            //Arrange
            const nonNumberParameter = '5';
            //Act
            const result = mathEnforcer.addFive(nonNumberParameter);
            //Assert
            expect(result).to.be.undefined;
        });

        it('Should return correct result, when positive number is given', () => {
            //Arrange
            const positiveNumberInput = 48;
            //Act
            const result = mathEnforcer.addFive(positiveNumberInput);
            //Assert
            expect(result).to.be.equal(53);
        });
        it('Should return correct result, when negative number is given', () =>{
            //Arrange
            const negativeNumberInput = -5;
            //Act
            const result = mathEnforcer.addFive(negativeNumberInput);
            //Assert
            expect(result).to.be.equal(0);
        });
        it('Should return correct result, when floating point number is given', () =>{
            //Arrange
            const floatingPointInput = 1.280000001;
            //Act
            const result = mathEnforcer.addFive(floatingPointInput);
            //Assert
            expect(result).to.be.closeTo(6.28, 0.01);
        });
    });
    describe('subtractTen', () => {
        it('Should return undefined, when non number parameter is given', () => {
            //Arrange
            const nonNumberParameter = '5';
            //Act
            const result = mathEnforcer.subtractTen(nonNumberParameter);
            //Assert
            expect(result).to.be.undefined;
        });

        it('Should return correct result, when positive number is given', () => {
            //Arrange
            const positiveNumberInput = 48;
            //Act
            const result = mathEnforcer.subtractTen(positiveNumberInput);
            //Assert
            expect(result).to.be.equal(38);
        });
        it('Should return correct result, when negative number is given', () =>{
            //Arrange
            const negativeNumberInput = -5;
            //Act
            const result = mathEnforcer.subtractTen(negativeNumberInput);
            //Assert
            expect(result).to.be.equal(-15);
        });
        it('Should return correct result, when floating point number is given', () =>{
            //Arrange
            const floatingPointInput = 1.2800000001;
            //Act
            const result = mathEnforcer.subtractTen(floatingPointInput);
            //Assert
            expect(result).to.be.closeTo(-8.72, 0.01);
        });
    });
    describe('sum', () => {
        it('Should return undefined, when non number parameters is given for first parameter', () => {
            //Arrange
            const nonNumberFirstParameter = '5';
            const secondParameter = 3;
            //Act
            const result = mathEnforcer.sum(nonNumberFirstParameter, secondParameter);
            //Assert
            expect(result).to.be.undefined;
        });
        it('Should return undefined, when non number parameters is given for second parameter', () => {
            //Arrange
            const firstParameter = 45;
            const nonNumberSecondParameter = '56';
            //Act
            const result = mathEnforcer.sum(firstParameter, nonNumberSecondParameter);
            //Assert
            expect(result).to.be.undefined;
        });

        it('Should return correct result, when positive numbers is given', () => {
            //Arrange
            const firstParameter = 48;
            const secondParameter = 7;
            //Act
            const result = mathEnforcer.sum(firstParameter, secondParameter);
            //Assert
            expect(result).to.be.equal(55);
        });
        it('Should return correct result, when negative numbers is given', () =>{
            //Arrange
            const firstParameter = -5;
            const secondParameter = -8
            //Act
            const result = mathEnforcer.sum(firstParameter, secondParameter);
            //Assert
            expect(result).to.be.equal(-13);
        });
        it('Should return correct result, when floating point number is given', () =>{
            //Arrange
            const firstParameter = -5.560000000000002;
            const secondParameter = 8
            //Act
            const result = mathEnforcer.sum(firstParameter, secondParameter);
            //Assert
            expect(result).to.be.closeTo(2.44, 0.01);
        });
        it('Should return correct result, when floating point number and zero is given', () =>{
            //Arrange
            const firstParameter = 0;
            const secondParameter = 0.1;
            //Act
            const result = mathEnforcer.sum(firstParameter, secondParameter);
            //Assert
            expect(result).to.be.closeTo(0.1, 0.01);
        });
    });
});