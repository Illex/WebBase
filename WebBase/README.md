Author: Ky Lamoureux
Partner: N/A
Date: 10/28/2021
Course CS 4540, University of Utah, School of Computing
Copyright: CS 4540 and Ky Lamoureux - This work may not be copied for use in Academic Coursework.

Deployed URL: NA
Github Page: https://github.com/Illex/WebBase.git

Comments to Evaluators:
	Because of the descrepancy in the naming scheme in the contoso tutorials, there is a small issue that
	sometimes appears in the _LoginPartial.cshtml.g.cs file where two instances of <TAUser> get renamed to <URCUser>
	this causes build errors, if this show up during evalueation please rename them back to <TAUser>. double clicking
	on the error in the error window will take you to the proper location so you can easily make the correction.

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
	