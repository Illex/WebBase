// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function setScreen() {
    //TODO: get something with graphics acceleration, otherwise development on this won't work
    
    const app = new PIXI.Application({
        width: 820, height: 740, backgroundColor: 0x1099bb, resolution: window.devicePixelRatio || 1,
    });

    //create a place to store all the things on screen
    //const containter = new PIXI.containter();

    //container.line(50, 50, 100, 100);

    const graphics = new PIXI.Graphics();
    
    for (i = 0; i < 5; i++) {
        //top row white out
        graphics.beginFill(0xFFFFFF);
        graphics.drawRect(160 * i + 15, 0, 150, 10);
        graphics.endFill();

        //bottom row white out
        graphics.beginFill(0xFFFFFF);
        graphics.drawRect(160 * i + 15, 735, 150, 10);
        graphics.endFill();
        for (j = 0; j < 48; j++) {
            graphics.beginFill(0x000000);
            graphics.drawRect(160 * i + 15, 15 * j + 15, 150, 10);
            graphics.endFill();

            //far left white out
            graphics.beginFill(0xFFFFFF);
            graphics.drawRect(0 , 15 * j + 15, 10, 10);
            graphics.endFill();
            //far right white out
            graphics.beginFill(0xFFFFFF);
            graphics.drawRect(810, 15 * j + 15, 10, 10);
            graphics.endFill();
        }        
    }

    //four corners white out
    graphics.beginFill(0xFFFFFF);
    graphics.drawRect(0, 0, 10, 10);
    graphics.endFill();

    graphics.beginFill(0xFFFFFF);
    graphics.drawRect(810, 0, 10, 10);
    graphics.endFill();

    graphics.beginFill(0xFFFFFF);
    graphics.drawRect(0, 735, 10, 10);
    graphics.endFill();

    graphics.beginFill(0xFFFFFF);
    graphics.drawRect(810, 735, 10, 10);
    graphics.endFill();

    app.stage.addChild(graphics);

    //const line = new PIXI.line()
    //select the proper html element and place the pixi object inside of it.
    document.getElementById("availability-table").appendChild(app.view);
    
}
