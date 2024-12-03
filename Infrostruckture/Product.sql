

create table product 
(
   id serial primary key ,
   product_name varchar(50) not null ,
   price decimal ,
   quantity int ,
   created_at date 
);

select * from product where id = @Id

insert into product(id, product_name, price, quantity, created_at) 
values (@Id,@ProductName,@Price,@Quantity,@CreatedAt);



update product set product_name=@ProductName,price=@Price,quantity=@Quantity,created_at=@CreatedAt where id = @Id

create database product_db