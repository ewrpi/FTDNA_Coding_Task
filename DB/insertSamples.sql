
SET IDENTITY_INSERT Samples ON
insert into Samples (SampleId,Barcode,CreatedAt,CreatedById,StatusId)
select SampleId,Barcode,CreatedAt,CreatedById,StatusId from ['Samples - Copy$']
SET IDENTITY_INSERT Samples OFF