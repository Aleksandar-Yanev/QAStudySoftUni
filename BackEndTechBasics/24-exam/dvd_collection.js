function dvd_collection (input)
{
    const numberOfDvds = parseInt(input[0], 10);
    const allDvds = input.slice(1, numberOfDvds+1);
    const allCommands = input.slice(numberOfDvds+1);

    outerLoop:
    for (let i = 0; i < allCommands.length; i++){
        const rawCommand = allCommands[i].split(' ');
        const commandName = rawCommand[0];

        switch(commandName){
            case 'Watch':
                const watchDvd = allDvds.shift();
                console.log(`${watchDvd} DVD watched!`)
                break;
            case 'Buy':
                const dvdToBuy = allCommands[i].slice(4);

                if (!dvdToBuy){
                    continue;
                }

                allDvds.push(dvdToBuy);
                break;
            case 'Swap':
                const firstIndex = parseInt(rawCommand[1], 10);
                const secondIndex = parseInt(rawCommand[2], 10);

                if (isNaN(firstIndex) || firstIndex < 0 || firstIndex >= allDvds.length) {
                    continue;
                }
    
                if (isNaN(secondIndex) || secondIndex < 0 || secondIndex >= allDvds.length) {
                    continue;
                }

                const firstDvd = allDvds[firstIndex];
                allDvds[firstIndex] = allDvds[secondIndex];
                allDvds[secondIndex] = firstDvd;

                console.log("Swapped!");
                break;
            case 'Done':
                break outerLoop;
        }      
    }
    
    if (allDvds.length) {
        console.log(`DVDs left: ${allDvds.join(', ')}`)
    } else {
        console.log("The collection is empty");
    }
}

//dvd_collection (['3', 'The Matrix', 'The Godfather', 'The Shawshank Redemption', 'Watch', 'Done', 'Swap 0 1'])
dvd_collection (['5', 'The Lion King', 'Frozen', 'Moana', 'Toy Story', 'Shrek', 'Buy Coco Boco', 'Swap 2 4', 'Done'])