using imc_web_api.Models;
using Microsoft.EntityFrameworkCore;

namespace imc_web_api.Service.AuthServices
{
    public class QualificationService : IQualificationService
    {
        private readonly ImcDbContext _imcDbContext;

        public QualificationService(ImcDbContext imcDbContext)
        {
            _imcDbContext = imcDbContext;
        }

        //-->> Add Qualification
        public async Task<user_qualification> AddQualification(user_qualification UserInputRequest)
        {
            try
            {
                if (UserInputRequest != null)
                {
                    await _imcDbContext.User_Qualifications.AddAsync(UserInputRequest);
                    await _imcDbContext.SaveChangesAsync();
                    return UserInputRequest;
                }
                else
                {
                    throw new Exception(" input field  can't be null");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Register" + ex.Message);
            }
        }

        //-->> Update Qualification
        public async Task<user_qualification> UpdateQualification(Guid id, user_qualification UserInputRequest)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("ID is required", nameof(id));
            }
            try
            {
                var ExistingQualification = await _imcDbContext.User_Qualifications.FirstOrDefaultAsync(q => q.Id == id);

                if (ExistingQualification == null)
                {
                    throw new Exception("Record not found!");
                }

                ExistingQualification.qualification = UserInputRequest.qualification;
                ExistingQualification.experience = UserInputRequest.experience;

                await _imcDbContext.SaveChangesAsync();
                return ExistingQualification;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Update Qualification", ex);
            }
        }

        //-->> Get Qualifications
        public async Task<List<user_qualification>> GetQualification()
        {
            try
            {
                return await _imcDbContext.User_Qualifications.Include(q => q.User).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Register", ex);
            }
        }

        //-->> Get Qualification By Id
        public async Task<user_qualification> GetQualificationById(Guid id)
        {
            try
            {
                return await _imcDbContext.User_Qualifications.Include(q => q.User).FirstOrDefaultAsync(uq => uq.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Fetch Qualification", ex);
            }
        }

        //-->> Delete Qualification
        public async Task<user_qualification> DeleteQualificationById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException("ID is required", nameof(id));
            }
            try
            {
                var qualificationToDelete = await _imcDbContext.User_Qualifications
           .Where(q => q.Id == id)
           .FirstOrDefaultAsync();

                if (qualificationToDelete != null)
                {
                    _imcDbContext.User_Qualifications.Remove(qualificationToDelete);
                    await _imcDbContext.SaveChangesAsync();
                }

                return qualificationToDelete;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to Delete Qualification", ex);
            }
        }
    }
}