export interface MenuNode {
    name: string;
    topic?: string;
    year?: string;
    month?: string;
    article?: string;
    children?: MenuNode[];
    count: number;
}
