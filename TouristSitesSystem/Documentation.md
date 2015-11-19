# Web Services Team "Zelus"
* Димитър Топалов - [topalkata](https://telerikacademy.com/Users/topalkata), GitHub: [dtopalov](https://github.com/dtopalov)
* Илияна Антова - [iliant](https://telerikacademy.com/Users/iliant), GitHub: [iliantova](https://github.com/iliantova)
* Кристина Йовева - [KYoveva](https://telerikacademy.com/Users/KYoveva), GitHub: [KYoveva](https://github.com/KYoveva)
* Любомир Свиленов - [LSvilenov](https://telerikacademy.com/Users/LSvilenov), GitHub: [LSvilenov](https://github.com/LSvilenov) 
* Николай Атанасов - [ni4ka7a](https://telerikacademy.com/Users/ni4ka7a), GitHub: [ni4ka7a](https://github.com/ni4ka7a) 

# Tourist Sites
* This is a project by the web services team "Zelus". It is a tourist portal which aims to represent the official list of the
"100 National Tourist Sites" in Bulgaria.<br />
The main purpose ot the site is to offer information about various places in Bulgaria and reach more people in oreder to show
them the beauty of the country.

* All users, registered or not, can see the tourist sites shown on the map of Bulgaria. For every tourist site a gallery of pictres
is available for the users to see the beauty of the place.<br/>
Registered user can add pictures for the tourist sites that they have visited. In that way they can help the developers of the site
to share more of the beauty of Bulgaria to the world.

# Class Diagram
![](https://github.com/WebServices-TeamZelus/TouristSitesSystem/blob/master/TouristSitesSystem/ClassDiagram.png)

# API Methods
* Images
  * Get - gets all ot the images from the database
  * GetById - gets the image with the given id from the database
  * Post - adds a new image in the database. This method can be used only by authorized users
  * Delete - deletes the image with the given id from the database. This method can be used only by authorized users
  * Put - updates an image in the database. This method can be used only by authorized users
  
* Tourist Sites
  * Get - gets all tourist sites from the database
  * GetById - gets the tourist site with the given id from the database
  * Post - adds new tourist site in the database. This method can be used only by authorized users
  * Delete - deletes the tourist site with the given id from the databse. This method can be used only by authorized users
  * Put - updates a tourist site in the database. This method can be used only by authorized users

* Cities
  * Get - gets all cities from the database
  * GetById - gets the city with the given id from the database
  * Search - gets the city with the given name from the database
  * 
* Accomodations
  * Get - gets all accomodations from the database
  * GetById - gets the accomodotion with the given id from the database
  * Post - adds an accomodation to the database. This method can be used only by authorized users
  * Delete - deletes an accomodation from the database, This method can be used only by authorized users
  * Put - this method changes an accomodation and saves the changes into the database. This method can be used only by authorized users

# URL of the source control repository
* [http://bgtouristsites.azurewebsites.net/](http://bgtouristsites.azurewebsites.net/)
