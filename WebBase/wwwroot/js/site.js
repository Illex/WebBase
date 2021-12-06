﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//array is temporary, will be populated with availability data
var timeSlots = [[true, true, true, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false],
[true, true, true, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false],
[true, true, true, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false],
[true, true, true, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false],
[true, true, true, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false]];

var app;

function setScreen() {    

    app = new PIXI.Application({
        width: 900, height: 750, backgroundColor: 0xFFFFFF, resolution: window.devicePixelRatio || 1,
    });


    //create a place to store all the things on screen
    const background = new PIXI.Graphics();
    //background color
    background.beginFill(0x000000);
    background.drawRoundedRect(0, 0, 820, 745);
    background.endFill();
    app.stage.addChild(background);

    let graphicObjects = new Array();
    
    for (i = 0; i < 5; i++) {       
        for (j = 0; j < 48; j++) {


            temp = new PIXI.Graphics();
            if (timeSlots[i][j] == true) {                
                temp.beginFill(0xFFFFFF);
            }
            else {
                temp.beginFill(0x1099bb);
            }            
            temp.drawRoundedRect(160 * i + 15, 15 * j + 15, 150, 10);
            temp.interactive = true;
            temp.buttonMode = true;
            temp.on("click", onClick);
            //temp.on("mousedown", onClick);
            temp.endFill();
            graphicObjects.push(temp);

            //add a highlight line for each hour
            if (j % 4 == 0) {
                line = new PIXI.Graphics();                
                line.beginFill(0xFFFFFF);
                line.drawRect(160 * i, 15 * j + 12, 180, 2);
                line.endFill();
                graphicObjects.push(line);
            }    
        }        
    }

    //extra highlight line on botton
    line = new PIXI.Graphics();
    line.beginFill(0xFFFFFF);
    // magic numbers bad
    line.drawRect(0, 732, 820, 2);
    line.endFill();
    graphicObjects.push(line);

    graphicObjects.forEach(function (element) { app.stage.addChild(element) });

    //draw text
    style = new PIXI.TextStyle({
        fontFamily: 'Arial',
        fontSize: 10,
        fill: ['0xffffff']
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
    
    //app.stage.addChild(graphics);
    app.stage.addChild(Monday);
    app.stage.addChild(Tuesday);
    app.stage.addChild(Wednesday);
    app.stage.addChild(Thursday);
    app.stage.addChild(Friday);

    style = new PIXI.TextStyle({
        fontFamily: 'Arial',
        fontSize: 10,
        fill: ['0c000000']
        //strokeThickness: 2,
    });

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

    //select the proper html element and place the pixi object inside of it.
    document.getElementById("availability-table").appendChild(app.view);
    
}

function onClick() {
    //do highlighting stuff    
    console.log(this.getLocalBounds());
    let bounds = this.getLocalBounds();
    const newRect = new PIXI.Graphics();

    document.getElementById('saveNotify').hidden = false;
    //document.getElementById(id);

    //undo the above math to find the array index
    //if the array at (x - 15)/160 , (y -15)/15
    indexI = (bounds.x - 15) / 160;
    indexJ = (bounds.y - 15) / 15;
    if (timeSlots[indexI][indexJ] == true) {
        //set to false
        timeSlots[indexI][indexJ] = false;
        newRect.beginFill(0x1099bb);
    }
    else {
        //set to true
        timeSlots[indexI][indexJ] = true;
        newRect.beginFill(0xFFFFFF);
    }
    newRect.drawRoundedRect(bounds.x, bounds.y, 150, 10);
    newRect.endFill();
    app.stage.addChild(newRect);
}

function saveClick() {
    //TODO: find a way to send info back to the server
    console.log("changes saved");
    document.getElementById('saveNotify').hidden = true;   
    document.getElementById('spinner').hidden = false;
    setTimeout(myFunction, 3000);  
}    

//TODO: remove this and replace it when data is moving between the view and the server properly
function myFunction() {
    document.getElementById('spinner').hidden = true;

}

function buildChart() {
    console.log("building chart");
}

Highcharts.chart('container', {

    title: {
        text: 'Solar Employment Growth by Sector, 2010-2016'
    },

    subtitle: {
        text: 'Source: thesolarfoundation.com'
    },

    yAxis: {
        title: {
            text: 'Number of Employees'
        }
    },

    xAxis: {
        accessibility: {
            rangeDescription: 'Range: 2010 to 2017'
        }
    },

    legend: {
        layout: 'vertical',
        align: 'right',
        verticalAlign: 'middle'
    },

    plotOptions: {
        series: {
            label: {
                connectorAllowed: false
            },
            pointStart: 2010
        }
    },

    series: [{
        name: 'Installation',
        data: [43934, 52503, 57177, 69658, 97031, 119931, 137133, 154175]
    }, {
        name: 'Manufacturing',
        data: [24916, 24064, 29742, 29851, 32490, 30282, 38121, 40434]
    }, {
        name: 'Sales & Distribution',
        data: [11744, 17722, 16005, 19771, 20185, 24377, 32147, 39387]
    }, {
        name: 'Project Development',
        data: [null, null, 7988, 12169, 15112, 22452, 34400, 34227]
    }, {
        name: 'Other',
        data: [12908, 5948, 8105, 11248, 8989, 11816, 18274, 18111]
    }],

    responsive: {
        rules: [{
            condition: {
                maxWidth: 500
            },
            chartOptions: {
                legend: {
                    layout: 'horizontal',
                    align: 'center',
                    verticalAlign: 'bottom'
                }
            }
        }]
    }

});
