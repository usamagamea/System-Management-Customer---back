Creating project to insert customer with customer data contain three model
 
      Country:
    
 Countryid int
Countryname string
 
    City:
 
Cityid int
Cityname string
 
Customer:
Customerid int
 
Customername string
 
Countryid int  ref to countryid
 
Cityid int ref to cityid
 
Phonenumber string
 
Address string
 
Create three screen to insert data to country and city and customerdata
 
Country and city will be dropdown allow auto complete
 
City cascade on country dropdown
