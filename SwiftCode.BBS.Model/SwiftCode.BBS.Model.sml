<?xml version="1.0"?>
<doc>
    <assembly>
        <name>SwiftCode.BBS.Model</name>
    </assembly>
    <members>
        <member name="T:SwiftCode.BBS.Model.MessageModel`1">
            <summary>
            负责返回通用信息类
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.MessageModel`1.status">
            <summary>
            状态码
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.MessageModel`1.success">
            <summary>
            操作是否成功
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.MessageModel`1.message">
            <summary>
            返回信息
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.MessageModel`1.response">
            <summary>
            返回数据集合
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.Models.Advertisement">
            <summary>
            广告
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Advertisement.ImgUrl">
            <summary>
            广告图片
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Advertisement.Url">
            <summary>
            广告链接
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Advertisement.CreateTime">
            <summary>
            创建时间
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.Models.Article">
            <summary>
            文章
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Article.Title">
            <summary>
            标题
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Article.Cover">
            <summary>
            封面
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Article.Content">
            <summary>
            内容
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Article.Tag">
            <summary>
            类别
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Article.Traffic">
            <summary>
            访问量
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Article.CreateTime">
            <summary>
            创建时间
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Article.CreateUserId">
            <summary>
            创建用户
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Article.CreateUser">
            <summary>
            创建用户
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Article.CollectionArticles">
            <summary>
            收藏文章的用户
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Article.ArticleComments">
            <summary>
            文章评论
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.Models.ArticleComment">
            <summary>
            文章评论
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.ArticleComment.Content">
            <summary>
            内容
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.ArticleComment.CreateTime">
            <summary>
            创建时间
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.ArticleComment.CreateUserId">
            <summary>
            创建用户
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.ArticleComment.CreateUser">
            <summary>
            创建用户
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.ArticleComment.ArticleId">
            <summary>
            文章Id
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.ArticleComment.Article">
            <summary>
            文章信息
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.Models.Question">
            <summary>
            问答
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Question.Title">
            <summary>
            标题
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Question.Content">
            <summary>
            内容
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Question.Tag">
            <summary>
            类别
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Question.Traffic">
            <summary>
            访问量
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Question.CreateTime">
            <summary>
            创建时间
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Question.CreateUserId">
            <summary>
            创建用户
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Question.CreateUser">
            <summary>
            创建用户
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.Question.QuestionComments">
            <summary>
            问答评论
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.Models.QuestionComment">
            <summary>
            问答评论
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.QuestionComment.Content">
            <summary>
            内容
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.QuestionComment.CreateTime">
            <summary>
            创建时间
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.QuestionComment.IsAdoption">
            <summary>
            是否采纳
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.QuestionComment.CreateUserId">
            <summary>
            创建用户
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.QuestionComment.CreateUser">
            <summary>
            创建用户
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.QuestionComment.QuestionId">
            <summary>
            问答Id
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.QuestionComment.Question">
            <summary>
            问答信息
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.Models.UserCollectionArticle">
            <summary>
            用户文章收藏表
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.UserCollectionArticle.UserId">
            <summary>
            用户Id
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.UserCollectionArticle.ArticleId">
            <summary>
            文章Id
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.Models.UserInfo">
            <summary>
            用户表
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.UserInfo.UserName">
            <summary>
            用户名
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.UserInfo.LoginName">
            <summary>
            登录账号
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.UserInfo.LoginPassWord">
            <summary>
            登录密码
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.UserInfo.Phone">
            <summary>
            手机号
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.UserInfo.Introduction">
            <summary>
            个人介绍
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.UserInfo.Email">
            <summary>
            邮箱
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.UserInfo.HeadPortrait">
            <summary>
            头像
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.UserInfo.CreateTime">
            <summary>
            创建时间
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.Models.RootEntityTkey`1">
            <summary>
            泛型主键类
            </summary>
            <typeparam name="Tkey"></typeparam>
        </member>
        <member name="P:SwiftCode.BBS.Model.Models.RootEntityTkey`1.Id">
            <summary>
            ID
            泛型主键Tkey
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.Model.RootTKey.RootEntityTKey`1">
            <summary>
            泛型主键类
            </summary>
            <typeparam name="Tkey"></typeparam>
        </member>
        <member name="P:SwiftCode.BBS.Model.Model.RootTKey.RootEntityTKey`1.Id">
            <summary>
            泛型主键
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.TableModel`1">
            <summary>
            表格数据，支持分页
            </summary>
            <typeparam name="T"></typeparam>
        </member>
        <member name="P:SwiftCode.BBS.Model.TableModel`1.Code">
            <summary>
            返回编码
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.TableModel`1.Msg">
            <summary>
            返回信息
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.TableModel`1.Count">
            <summary>
            返回总数
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.TableModel`1.Data">
            <summary>
            返回数据集
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.TipsModel">
            <summary>
            统一提示类
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.TipsModel.NameOrPasswordNull">
            <summary>
            
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.TipsModel.AccountNotFound">
            <summary>
            
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.TipsModel.GetSuccess">
            <summary>
            
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.TipsModel.AccountExist">
            <summary>
            
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.TipsModel.EmailExist">
            <summary>
            
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.TipsModel.PhoneExist">
            <summary>
            
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.TipsModel.NameExist">
            <summary>
            
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.TipsModel.RegistSuccess">
            <summary>
            
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.TipsModel.CreateSucccess">
            <summary>
            
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.TipsModel.UpdateSuccess">
            <summary>
            
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.TipsModel.DeleteSuccess">
            <summary>
            
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.TipsModel.CollectionSuccess">
            <summary>
            
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.TipsModel.CommentSuccess">
            <summary>
            
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.TipsModel.DeleteCommentSuccess">
            <summary>
            
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.ViewModels.Article.ArticleCommentDto">
            <summary>
            文章评论Dto
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleCommentDto.Content">
            <summary>
            内容
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleCommentDto.CreateTime">
            <summary>
            创建时间
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleCommentDto.CreateUserId">
            <summary>
            创建用户
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleCommentDto.UserName">
            <summary>
            用户名
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleCommentDto.HeadPortrait">
            <summary>
            头像
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.ViewModels.Article.ArticleDetailsDto">
            <summary>
            文章详情Dto
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleDetailsDto.Title">
            <summary>
            标题
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleDetailsDto.Cover">
            <summary>
            封面
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleDetailsDto.Content">
            <summary>
            内容
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleDetailsDto.Tag">
            <summary>
            类别
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleDetailsDto.Traffic">
            <summary>
            访问量
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleDetailsDto.CreateTime">
            <summary>
            创建时间
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleDetailsDto.CreateUserId">
            <summary>
            创建用户
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleDetailsDto.ArticleComments">
            <summary>
            文章评论
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.ViewModels.Article.ArticleDto">
            <summary>
            文章Dto
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleDto.Title">
            <summary>
            标题
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleDto.Cover">
            <summary>
            封面
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleDto.Content">
            <summary>
            内容
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleDto.Tag">
            <summary>
            类别
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleDto.CreateTime">
            <summary>
            创建时间
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleDto.CreateUserId">
            <summary>
            创建用户
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleDto.UserName">
            <summary>
            用户名
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.ArticleDto.HeadPortrait">
            <summary>
            头像
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.ViewModels.Article.CreateArticleCommentsInputDto">
            <summary>
            创建文章评论Dto
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.CreateArticleCommentsInputDto.Content">
            <summary>
            评论内容
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.ViewModels.Article.CreateArticleInputDto">
            <summary>
            创建文章Dto
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.CreateArticleInputDto.Title">
            <summary>
            标题
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.CreateArticleInputDto.Cover">
            <summary>
            封面
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.CreateArticleInputDto.Content">
            <summary>
            内容
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.CreateArticleInputDto.Tag">
            <summary>
            类别
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.ViewModels.Article.UpdateArticleInputDto">
            <summary>
            修改文章Dto
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.UpdateArticleInputDto.Title">
            <summary>
            标题
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.UpdateArticleInputDto.Cover">
            <summary>
            封面
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.UpdateArticleInputDto.Content">
            <summary>
            内容
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Article.UpdateArticleInputDto.Tag">
            <summary>
            类别
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.ViewModels.Question.CreateQuestionCommentsInputDto">
            <summary>
            创建问答评论Dto
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.CreateQuestionCommentsInputDto.Content">
            <summary>
            评论内容
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.ViewModels.Question.CreateQuestionInputDto">
            <summary>
            创建问答Dto
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.CreateQuestionInputDto.Title">
            <summary>
            标题
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.CreateQuestionInputDto.Content">
            <summary>
            内容
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.CreateQuestionInputDto.Tag">
            <summary>
            类别
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.ViewModels.Question.QuestionCommentDto">
            <summary>
            问答评论Dto
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.QuestionCommentDto.Content">
            <summary>
            内容
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.QuestionCommentDto.CreateTime">
            <summary>
            创建时间
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.QuestionCommentDto.IsAdoption">
            <summary>
            是否采纳
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.QuestionCommentDto.CreateUserId">
            <summary>
            创建用户
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.QuestionCommentDto.UserName">
            <summary>
            用户名
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.QuestionCommentDto.HeadPortrait">
            <summary>
            头像
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.ViewModels.Question.QuestionDetailsDto">
            <summary>
            问答详情Dto
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.QuestionDetailsDto.Title">
            <summary>
            标题
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.QuestionDetailsDto.Tag">
            <summary>
            类别
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.QuestionDetailsDto.QuestionCommentCount">
            <summary>
            问答数量
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.QuestionDetailsDto.CreateTime">
            <summary>
            创建时间
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.QuestionDetailsDto.QuestionComments">
            <summary>
            问答评论
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.ViewModels.Question.QuestionDto">
            <summary>
            问答Dto
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.QuestionDto.Title">
            <summary>
            标题
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.QuestionDto.Tag">
            <summary>
            类别
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.QuestionDto.CreateTime">
            <summary>
            创建时间
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.QuestionDto.CreateUserId">
            <summary>
            创建用户
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.QuestionDto.QuestionCommentCount">
            <summary>
            问答数量
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.ViewModels.Question.UpdateQuestionInputDto">
            <summary>
            修改问答Dto
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.UpdateQuestionInputDto.Title">
            <summary>
            标题
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.UpdateQuestionInputDto.Content">
            <summary>
            内容
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.Question.UpdateQuestionInputDto.Tag">
            <summary>
            类别
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.ViewModels.UserInfo.CreateUserInfoInputDto">
            <summary>
            用户注册Dto
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.UserInfo.CreateUserInfoInputDto.UserName">
            <summary>
            用户名
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.UserInfo.CreateUserInfoInputDto.LoginName">
            <summary>
            登录账号
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.UserInfo.CreateUserInfoInputDto.LoginPassWord">
            <summary>
            登录密码
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.UserInfo.CreateUserInfoInputDto.Phone">
            <summary>
            手机号
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.UserInfo.CreateUserInfoInputDto.Introduction">
            <summary>
            个人介绍
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.UserInfo.CreateUserInfoInputDto.Email">
            <summary>
            邮箱
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.UserInfo.CreateUserInfoInputDto.HeadPortrait">
            <summary>
            头像
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.ViewModels.UserInfo.UpdateUserInfoInputDto">
            <summary>
            修改个人信息Dto
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.UserInfo.UpdateUserInfoInputDto.Introduction">
            <summary>
            个人介绍
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.UserInfo.UpdateUserInfoInputDto.Email">
            <summary>
            邮箱
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.UserInfo.UpdateUserInfoInputDto.HeadPortrait">
            <summary>
            头像
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.ViewModels.UserInfo.UserInfoDetailsDto">
            <summary>
            用户信息详情Dto
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.UserInfo.UserInfoDetailsDto.UserName">
            <summary>
            用户名
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.UserInfo.UserInfoDetailsDto.Phone">
            <summary>
            手机号
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.UserInfo.UserInfoDetailsDto.Introduction">
            <summary>
            个人介绍
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.UserInfo.UserInfoDetailsDto.Email">
            <summary>
            邮箱
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.UserInfo.UserInfoDetailsDto.HeadPortrait">
            <summary>
            头像
            </summary>
        </member>
        <member name="T:SwiftCode.BBS.Model.ViewModels.UserInfo.UserInfoDto">
            <summary>
            个人信息Dto
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.UserInfo.UserInfoDto.UserName">
            <summary>
            用户名
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.UserInfo.UserInfoDto.HeadPortrait">
            <summary>
            头像
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.UserInfo.UserInfoDto.ArticlesCount">
            <summary>
            文章数量
            </summary>
        </member>
        <member name="P:SwiftCode.BBS.Model.ViewModels.UserInfo.UserInfoDto.QuestionsCount">
            <summary>
            问答数量
            </summary>
        </member>
    </members>
</doc>
