// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function setScreen() {
    //TODO: get something with graphics acceleration, otherwise development on this won't work
    
    const app = new PIXI.Application({
        width: 900, height: 860, backgroundColor: 0xFFFFFF, resolution: window.devicePixelRatio || 1,
    });

    //create a place to store all the things on screen
    const graphics = new PIXI.Graphics();

    //background color
    graphics.beginFill(0x1099bb);
    graphics.drawRect(0, 0, 820, 745);
    graphics.endFill();
    
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

            //add a highlight line for each hour
            if (j % 4 == 0) {
                graphics.beginFill(0xad0909);
                graphics.drawRect(160 * i, 15 * j + 10, 180, 5);
                graphics.endFill();
            }

            //far left white out
            graphics.beginFill(0xFFFFFF);
            graphics.drawRect(0 , 15 * j + 15, 10, 10);
            graphics.endFill();
            //far right white out
            graphics.beginFill(0xFFFFFF);
            graphics.drawRect(810, 15 * j + 15, 820, 10);
            graphics.endFill();
        }        
    }

    //extra highlight line on botton
    graphics.beginFill(0xad0909);
    // magic numbers bad
    graphics.drawRect(0, 730, 820, 5);
    graphics.endFill();

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

    //draw text
    const style = new PIXI.TextStyle({
        fontFamily: 'Arial',
        fontSize: 10,       
        //strokeThickness: 2,
     });
    const Monday = new PIXI.Text('Monday',style);
    Monday.x = 60;
    Monday.y = 0;

    const Tuesday = new PIXI.Text('Tuesday', style);
    Tuesday.x = 220;
    Tuesday.y = 0;

    const Wednesday = new PIXI.Text('Wednesday', style);
    Wednesday.x = 380;
    Wednesday.y = 0;

    const Thursday = new PIXI.Text('Thursday', style);
    Thursday.x = 550;
    Thursday.y = 0;

    const Friday = new PIXI.Text('Friday', style);
    Friday.x = 710;
    Friday.y = 0;


    
    app.stage.addChild(graphics);
    app.stage.addChild(Monday);
    app.stage.addChild(Tuesday);
    app.stage.addChild(Wednesday);
    app.stage.addChild(Thursday);
    app.stage.addChild(Friday);

    for (i = 0; i <= 12; i++) {
        t = (i + 8) % 12;
        if (t == 0) {
            t = 12
        }

        temp = 'AM'
        if (i + 8 >= 12) {
            temp = 'PM'
        }

        time = new PIXI.Text(t + ':00 ' + temp, style)
        time.x = 825;
        time.y = i * 60 + 6;
        app.stage.addChild(time);
    }

    

    //const line = new PIXI.line()
    //select the proper html element and place the pixi object inside of it.
    document.getElementById("availability-table").appendChild(app.view);
    
}
