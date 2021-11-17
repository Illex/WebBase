// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function setScreen() {
    //TODO: get something with graphics acceleration, otherwise development on this won't work
    
    const app = new PIXI.Application({
        width: 800, height: 600, backgroundColor: 0x1099bb, resolution: window.devicePixelRatio || 1,
    });

    //create a place to store all the things on screen
    //const containter = new PIXI.containter();

    //container.line(50, 50, 100, 100);

    //const graphics = new PIXI.graphics();

    //graphics.beginFill(0x000000);
    //graphics.drawRect(50, 50, 100, 100);
    //graphics.endFill();    

    //const line = new PIXI.line()
    //select the proper html element and place the pixi object inside of it.
    document.getElementById("availability-table").appendChild(app.view);
    
}
