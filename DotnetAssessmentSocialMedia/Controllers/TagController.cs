using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetAssessmentSocialMedia.Controllers
{
    public class TagController
    {
        private readonly ITagService _tagService;

        private readonly IMapper _mapper;

        private readonly ILogger _logger;

        public UserController(ITagService tagService, IMapper mapper, ILogger<TagController> logger)
        {
            _tagService = tagService;
            _mapper = mapper;
            _logger = logger;
        }

        // GET validate/tag/exists/{label}
        [HttpGet("validate/tag/exists/{label}")]
        public void GetTagExists(int label) { }

        

       
    }
}
