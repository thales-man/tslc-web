export interface PostedArticle {
    article: string;
    title: string;
    topic: string;
    year?: string;
    month?: string;
    publicationDate: Date;
    alias?: string;
    path: string;
}
