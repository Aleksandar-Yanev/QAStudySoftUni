import {isOddOrEven} from './01-even-or-odd.js';
import {expect} from 'chai';

describe('isOddOrEven', () => {
    it('Should return undefined, when not string is given', () => {
        //Arrange
        //Act
        const resultInt = isOddOrEven(78);
        const resultNull = isOddOrEven(null);
        const resultObject = isOddOrEven({});
        //Assert
        expect(resultInt).to.be.undefined;
        expect(resultNull).to.be.undefined;
        expect(resultObject).to.be.undefined;
    });
    it('Should return even, when string with even length is given', () => {
        //Arrange

        //Act
        const resultEven = isOddOrEven('abvf');
        //Assert
        expect(resultEven).to.be.equal('even');
    });
    it ('Should return odd, when string with odd length is given', () =>{
        //Arrange

        //Act
const resultOdd = isOddOrEven('qwe');
        //Assert
        expect(resultOdd).to.be.equal('odd');
    });
    it ('Should return even, when string with zero length is given', () =>{
        //Arrange

        //Act
const resultZeroLengthString = isOddOrEven('');
        //Assert
        expect(resultZeroLengthString).to.be.equal('even');
    });
});