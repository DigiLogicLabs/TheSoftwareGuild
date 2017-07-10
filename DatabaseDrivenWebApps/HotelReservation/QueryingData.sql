USE HotelReservation

INSERT INTO Customer (Name, [Address], Phone, Email)
VALUES ('Conner' , '21201 Larkin Rd', '6129006357', 'csharpener22@gmail.com')--done
GO
INSERT INTO PromoCode VALUES ( '05-22-1995', 0.05, 10, 'business')--Done

INSERT INTO Amenity VALUES ('HotTub') --DONE

INSERT INTO AddOn VALUES ('RoomService', 20) -- DONE

INSERT INTO Room VALUES (122, 6) --DONE

INSERT INTO BedType VALUES (2, 'King') --DONE 

INSERT INTO RoomAmenity VALUES (1,1) --DONE

INSERT INTO RoomBedType VALUES (1,1) --DONE

INSERT INTO Bill VALUES (1, 0.15, 205)--DONE

INSERT INTO BillAddOn VALUES (1,1) --DONE

INSERT INTO Reservation VALUES ('5-22-1995', '5-22-1996', 'Business', 1, 1) --DONE

INSERT INTO Guest VALUES ( 22, 'Conner', 6)

