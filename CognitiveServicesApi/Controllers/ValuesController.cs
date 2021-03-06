﻿using CognitiveServicesCore;
using EmotionAnalysis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace CognitiveServicesApi.Controllers
{
    public class ValuesController : ApiController
    {
        // http://localhost:56420/api/emotionanalysis/c8684209-e2c1-4413-aa39-f87a423c4742
        [HttpGet]
        [ResponseType(typeof(EmotionAnalysisResultSet))]
        [Route("api/emotionanalysis/{sessionId:Guid}")]
        public async Task<EmotionAnalysisResultSet> GetFaceAnalysisResultSetBySessionId([FromUri] Guid sessionId)
        {
            EmotionAnalysisEngine emotionAnalysisEngine = new EmotionAnalysisEngine();

            var response = await emotionAnalysisEngine.GetAnalysisResultSet(sessionId).ConfigureAwait(false);
            return response;
        }

        [HttpPost]
        [ResponseType(typeof(FaceAnalysisDocument))]
        [Route("api/emotionanalysis/{sessionId:Guid}")]
        public async Task<FaceAnalysisDocument> AnalyseEmotion([FromUri] Guid sessionId, [FromBody] byte[] imageArray)
        {
            EmotionAnalysisEngine emotionAnalysisEngine = new EmotionAnalysisEngine();

            var response = await emotionAnalysisEngine.AnalyseEmotion(sessionId, imageArray).ConfigureAwait(false);
            return response;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
