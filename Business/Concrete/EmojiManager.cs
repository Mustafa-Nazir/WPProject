using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class EmojiManager : IEmojiService
    {
        IEmojiDal _emojiDal;

        public EmojiManager(IEmojiDal emojiDal)
        {
            _emojiDal = emojiDal;
        }

        public IResult Add(Emoji entity)
        {
            _emojiDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Emoji entity)
        {
            _emojiDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Emoji>> GetAll()
        {
            List<Emoji> emojis = _emojiDal.GetAll();
            return new SuccessDataResult<List<Emoji>>(emojis);
        }

        public IDataResult<Emoji> GetById(int id)
        {
            Emoji emoji = _emojiDal.Get(e => e.Id == id);
            return new SuccessDataResult<Emoji>(emoji);
        }

        public IResult Update(Emoji entity)
        {
            _emojiDal.Update(entity);
            return new SuccessResult();
        }
    }
}
