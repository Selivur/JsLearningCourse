type Image = {
  type: "image";
  src: string;
  alt: string;
};

type Heading = {
  type: "heading";
  text: string;
};

type Subheading = {
  type: "subheading";
  text: string;
};

type Paragraph = {
  type: "paragraph";
  text: string;
};

type List = {
  type: "list";
  items: string[];
};

export type CodeSnippet = {
  type: "code";
  code: string;
  language?: string;
};

export type Content =
  | Heading
  | Subheading
  | Paragraph
  | Image
  | List
  | CodeSnippet;

export type Topic = {
  id: number;
  title: string;
  test?: boolean;
  content: Content[];
};

export type Section = {
  id: number;
  title: string;
  topics: Topic[];
};

export type ContentSection = {
  id: number;
  title: string;
  sections: Section[];
};
