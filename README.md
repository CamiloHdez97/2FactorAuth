# 2FactorAuth

#1. Arquitectura 4 Capas:
  
  1.1. API
  1.2. Domain
  1.3. Aplication
  1.4. Persistence


#2. Dependencias:

  2.1. EntityFrameworkCore:
  
  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/9031849f-48bc-40ac-9568-e37ef90a4dbe)


  2.2. Pomelo, para la conexión a la base de datos:

  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/736c44a6-9309-47a5-9b02-4999df3830e0)

  2.3. AutoMapper (DependencyInjection), para mapear los DTOs

  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/26132d95-b71e-47a2-b043-68540a49cc14)

  2.4. TwoFactorAuth.Net, Instalamos las dos dependencias en API

  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/e0fd274b-9616-43d1-b5e6-a685040fff2e)

     
#3. Domain:
   
   Creación de la entidad user y Base entity:
   
   ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/d378698a-777b-45c8-9a8e-37f9f5306ddf)

   ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/2cfa5dff-acd9-4184-a72e-ff87a93821be)


#4. Creación de las interfaces:

   ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/d092d45b-7c9a-483c-92a6-ee7e62233729)

  3.1. IGenericRepository:
  
   ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/bf31d330-10be-433b-a1cc-af071f45ee42)

  3.2. IUserRepository:
  
  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/119b6c2b-242e-4bd1-9bd9-623d72fd7c42)

  3.3. IUnitOfWork:

  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/fea94edb-601a-483a-ae33-8a89d3c05a17)


#5. Persistence:
  
  5.1. Creamos el DbContext(ApiContext) en Persistence:

  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/f4fed108-489c-418e-8752-85c1a1fb36e4)

  5.2. Creamos la clase de Configuración teniendo en cuenta los atriutos y tipos de datos, para migrar la tabla a la DB
  
  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/85f74512-ab79-4060-9f04-787720085fd2)

  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/2adbe336-1af9-4d9d-8230-27dcfa973439)


#6 Aplication:

  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/d9713ad1-a559-4924-a2b6-8188781fb7c7)

  6.1. Creamos GenericRepository:
  
  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/13c745ec-ebdc-4ad2-9689-8bbd74ca0205)
  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/51d7991e-4375-43ef-aa8e-74cbf549bbfb)

  6.2. Creamos UserRepository:
  
  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/be84d593-3ab9-4242-b766-2c3a5ed9cc47)

  6.3. UnitOfWork

  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/224a3dd1-d0ba-4b82-831c-ae2458c97bbb)
  

#7. Api:

  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/c91decf8-4c71-466e-a4c7-135552d1488b)

  7.1. Configuramos la conexión a la DB, en appsettings.Development.json:

  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/8a9bd557-06a7-40ce-9c8e-12da4b0cd38b)

  7.2. Injectamos la conexión en el Program.cs
  
  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/656203f1-eabe-4552-97f1-0233fd2b6ad4)

  7.3. Creamos una migración:
  
  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/60b04795-c62d-4fe7-88d8-b0f4d98343ac)

  7.4. Aplicamos la migración:
  
  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/58a1744a-cee3-4d3e-bad7-7cd5cd144b93)

  7.5. Creamos la interface ITwoAuthService.sc

  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/0b800859-034b-4505-9098-0c486684027a)

  7.6. Creamos TwoAuthService.cs e implementamos la interface

  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/00a05982-d3c8-40cd-bc55-ea511f0fbb36)
  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/f964ec65-eca4-4603-b311-d48b77f6cfe1)

  7.7. Creamos el DTO de User
  
  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/bbe73aa2-107d-4f28-9adf-42140b98f8f1)

  7.8. En la carpeta Profiles agregamos el Mapping el cual realizara el mapeo del Dto

  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/34a0fc78-2da4-4156-8cd7-1eeb608aafa2)

  7.9. ApplicationServiceExtension

  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/9de463ff-03fd-47d9-ae93-dd03646b489a)

#8. Controladores

  8.1 Implementamos un controlador Base
  
  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/7ca88c0d-2b0a-410f-8b83-6dd6ad7f01f4)

  8.2. Implementamos el controlador User y heredamos el controlador Base

  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/78d2eb2d-612a-4be7-a452-a994ec9515f1)
  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/922e3195-5577-4c50-a097-9c72ab78db08)
  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/cef7bedd-c10c-489e-bb57-9ed61c4ba193)

# 9. Lanzamos el servidor:

  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/c2b65aea-e1f8-43da-89c4-7b8b0451efd9)

#10. Accedemos a la ruta 
  
  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/da70b990-7d9a-4d18-ab00-8b387724f051)

  10.1. Realizamos el escaneo con una aplicación de Autenticator Code Qr   

  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/2eed0dcc-211d-4d13-a7e3-3cf082115a9d)

  10.2. Para verificar el codigo vamos al apartado de verify, pasamos el "id" del usuario y         especificamos el codigo de la app en "key". Por ultimo enviamos la petición.

  ![image](https://github.com/CamiloHdez97/2FactorAuth/assets/45055602/ab15705a-422c-474b-a0eb-04964cf82ebf)


  

  



    

      


  
  

  

  

  
  

  

  


   
   





