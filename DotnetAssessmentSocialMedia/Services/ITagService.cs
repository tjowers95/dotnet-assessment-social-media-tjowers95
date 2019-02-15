using DotnetAssessmentSocialMedia.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetAssessmentSocialMedia.Services
{
    public interface ITagService
    {
        IEnumerable<TagResponseDto> GetAllTags();
        TagResponseDto GetTag(string label);
        bool CheckTag(string label);
    }
}
