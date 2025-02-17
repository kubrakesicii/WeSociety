﻿using WeSociety.Domain.Aggregates.ArticleRoot;
using WeSociety.Domain.Aggregates.ArticleRoot.Entities;
using WeSociety.Domain.Aggregates.ReadingListRoot;
using WeSociety.Domain.Aggregates.UserProfileRoot.Entities;
using WeSociety.Domain.Aggregates.UserRoot;
using WeSociety.Domain.Common;

namespace WeSociety.Domain.Aggregates.UserProfileRoot
{
    public class UserProfile : AggregateRoot
    {

        public byte[]? Image { get; private set; }
        public string FullName { get; private set; }
        public string Bio { get; private set; }

        public string Github { get; private set; }
        public string Linkedin { get; private set; }

        public string UserId { get; private set; }
        public AppUser User { get; private set; }

        public IList<Article> Articles { get; private set; }

        // Takip ettiğim kullanıcılar - burada ben FolllowerId olurum
        public IList<FollowRelationship> Followings { get; private set; }

        // Beni takip eden kullanıcılar - burada ben FolllowingId olurum
        public IList<FollowRelationship> Followers { get; private set; }

        //Many-to-many user article clapler
        public IList<ArticleClap> ArticleClaps { get; private set; }

        //Kullancıı birden fazla okuma listesi olabilir
        public IList<ReadingList> ReadingLists { get; private set; }

        public IList<ArticleComment> ArticleComments { get; private set; }



        public UserProfile(byte[]? image, string? fullName, string? bio, string? github, string? linkedin,string userId)
        {
            Image = image;
            FullName = fullName;
            Bio = bio;
            Github = github;
            Linkedin = linkedin;
            UserId = userId;
            Articles = new List<Article> { };
            Followings = new List<FollowRelationship> { };
            Followers = new List<FollowRelationship> { };
            ReadingLists=new List<ReadingList> { };
            ArticleComments=new List<ArticleComment> { };
            ArticleClaps=new List<ArticleClap> { };
        }

        public UserProfile(string userId)
        {
            Image = null;
            FullName = null;
            Bio = null;
            Github = null;
            Linkedin = null;
            UserId = userId;
            Articles = new List<Article> { };
            Followings = new List<FollowRelationship> { };
            Followers = new List<FollowRelationship> { };
            ReadingLists = new List<ReadingList> { };
            ArticleClaps = new List<ArticleClap> { };
        }

        public UserProfile(int id,string fullname, string bio)
        {
            Id = id;
            FullName = fullname;
            Bio = bio;          
        }

        public void Update(byte[]? image, string fullName, string bio, string github, string linkedin)
        {
            Image = image == null ? Image : image;
            FullName = fullName;
            Bio = bio;
            Github = github; 
            Linkedin = linkedin;
        }

        //Article bahavior methoda
        public Article AddArticle(string title,string domain, string content, bool isPublished,int categoryId, byte[]? mainImage)
        {
            Article article = new Article(title,domain, content, isPublished,categoryId, mainImage,Id);
            Articles.Add(article);
            return article;
        }

        public void DeleteArticle(Article article)
        {
            Articles.Remove(article);
        }


        // FOLLOW RELATION BEHAVIOR METHODS
        public FollowRelationship Follow(int followingId)
        {
            FollowRelationship followRel = new FollowRelationship(Id, followingId);
            Followings.Add(followRel);
            return followRel;
        }

        public FollowRelationship UnFollow(int followingId)
        {
            FollowRelationship followRel = new FollowRelationship(Id, followingId);
            var removedFollowRel = Followings.FirstOrDefault(x => x.FollowingId == followingId);
            Followings.Remove(removedFollowRel);
            return removedFollowRel;
        }


        //Ben bu user'ı takip ediyor muyum?
        public bool IsFollowing(int userProfileId)
        {
            return Followings.Any(x => x.FollowingId == userProfileId);
        }

        //Create Reading List
        public void AddReadingList(string name)
        {
            if (name == null) throw new NullReferenceException();
            ReadingList readingList = new ReadingList(name, this.Id);
            ReadingLists.Add(readingList);
        }

        public void RemoveReadingList(ReadingList readingList)
        {
            ReadingLists.Remove(readingList);
        }


        //Clap Article
        public void ClapArticle(int articleId)
        {
            ArticleClap clap = new ArticleClap(Id, articleId);
            ArticleClaps.Add(clap);
        }

    }
}
