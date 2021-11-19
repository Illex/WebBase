Author: Ky Lamoureux
Partner: N/A
Date: 10/28/2021
Course CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Ky Lamoureux - This work may not be copied for use in Academic Coursework.

Deployed URL: ec2-18-215-20-74.compute-1.amazonaws.com  (not all local functionality works on aws)
Github Page: https://github.com/Illex/WebBase.git

Comments to Evaluators:
	There is a naming descrepancy due to the instructions for this assignment being incorrect, most of the basic 
	functionality works, Courses, login authentication, google authentication etc.  Amazon aws still has the 
	developer mode issue and won't allow google login eventhoug I did the static ip and added the uris with
	a nip.io address.  all that functionality however works on the local machine.

Assignment Specific Write-up:
	PS6 uses the authentication and database seeding written in ps5 to function. As a result, since my ps5 was very
	broken, In order to try and get this project off the ground I have built this assignment on a clean Contoso project.
	This means that this project only contains the requirements for ps6 and none of the code from my previous assignments.

	Secondly, I have run into a small issue with the secrets file, the given instrucitons never created a secrets file in
	the proper location and I wasn't able to figure out how to manually create and reference it.  This should not be a problem
	for the production build as we are supposed to use the appsettings.production.json file. If that doesn't work I will just
	leave my key strings in the code.  I am very well aware that this is terrible coding practice and I wouldn't do this
	on actual production code but for the purposes of showing that my google login works, this is the solutio I will go with.

Peers Helped:
	N/A

Peers Consulted:
	N/A

Acknowledgements:

References:	


    $.ajax({
        url: '@Url.Action("GetSchedule", "SlotsController")',

        success: function (data) { alert("got message back") },

        dataType: JSON
    });
	