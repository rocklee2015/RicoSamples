<Query Kind="SQL" />

--定义游标
declare m_cursor cursor scroll for
select Id, ApplyStatus, DonorIdName, DonorIdCardNo, DonorIdCardFaceImage, DonorIdCardEmblemImage, DonorId, UseBloodIdName, UseBloodIdCardNo, UseBloodIdCardFaceImage, UseBloodIdCardEmblemImage from Reimbursement
where Applicant != '后台导入'
for update
-- 打开游标
open m_cursor
declare @Id uniqueidentifier, @ApplyStatus int, @DonorIdName nvarchar(60), @DonorIdCardNo nvarchar(60), @DonorIdCardFaceImage nvarchar(150), @DonorIdCardEmblemImage nvarchar(150), @DonorId nvarchar(60), @UseBloodIdName nvarchar(60), @UseBloodIdCardNo nvarchar(60), @UseBloodIdCardFaceImage nvarchar(150), @UseBloodIdCardEmblemImage nvarchar(150)
--填充数据
fetch next from m_cursor into @Id, @ApplyStatus, @DonorIdName, @DonorIdCardNo, @DonorIdCardFaceImage, @DonorIdCardEmblemImage, @DonorId, @UseBloodIdName, @UseBloodIdCardNo, @UseBloodIdCardFaceImage, @UseBloodIdCardEmblemImage
--假如检索到了数据，才处理
while @@FETCH_STATUS = 0
begin
	--更新状态
	update Reimbursement set  ApplyStatus = @ApplyStatus + 10 where current of m_cursor
    --添加献血者
    INSERT INTO[dbo].[BloodDonor]
([Id]
           ,[ReimbursementId]
           ,[IsDeleted]
           ,[CreateTime]
           ,[DeleteTime]
           ,[DonorName]
           ,[DonorCardId]
           ,[DonorCardFaceImage]
           ,[DonorCardEmblemImage]
           ,[DonorId])
     VALUES
		   (NEWID(), @Id, 0, GETDATE(), NULL, @DonorIdName, @DonorIdCardNo, @DonorIdCardFaceImage, @DonorIdCardEmblemImage, @DonorId)
	--添加用血者
	INSERT INTO[dbo].[BloodUser]
		   ([Id]
           ,[ReimbursementId]
           ,[IsDeleted]
           ,[CreateTime]
           ,[DeleteTime]
           ,[UserName]
           ,[UserCardId]
           ,[UserCardFaceImage]
           ,[UserCardEmblemImage])
     VALUES
		   (NEWID(), @Id, 0, GETDATE(), NULL, @UseBloodIdName, @UseBloodIdCardNo, @UseBloodIdCardFaceImage, @UseBloodIdCardEmblemImage)

	 print convert(nvarchar(100), @Id)+'-[成功]！'
	--填充下一条数据
	fetch next from m_cursor into  @Id,@ApplyStatus, @DonorIdName,@DonorIdCardNo,@DonorIdCardFaceImage,@DonorIdCardEmblemImage,@DonorId,@UseBloodIdName,@UseBloodIdCardNo,@UseBloodIdCardFaceImage,@UseBloodIdCardEmblemImage
end
--关闭游标
close m_cursor
--释放游标
deallocate m_cursor